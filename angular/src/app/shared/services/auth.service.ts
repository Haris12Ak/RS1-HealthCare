import { Injectable } from '@angular/core';
import { UserManager, User, UserManagerSettings } from 'oidc-client';
import { Constants } from '../constants';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private tokenresp: any;
  private _userManager: UserManager;
  private _user: User;
  private _loginChangedSubject = new Subject<boolean>();

  public loginChanged = this._loginChangedSubject.asObservable();
  private get idpSettings(): UserManagerSettings {
    return {
      authority: Constants.idpAuthority,
      client_id: Constants.clientId,
      redirect_uri: `${Constants.clientRoot}/signin-callback`,
      scope: "HealthCare",
      response_type: "code",
      post_logout_redirect_uri: `${Constants.clientRoot}/signout-callback`,
      automaticSilentRenew: true,
      silent_redirect_uri: `${Constants.clientRoot}/assets/silent-callback.html`
    }
  }
  constructor() {
    this._userManager = new UserManager(this.idpSettings);
    this._userManager.events.addAccessTokenExpired(_ => {
      this._loginChangedSubject.next(false);
    });
  }
  public login = () => {
    return this._userManager.signinRedirect();
  }
  public isAuthenticated = (): Promise<boolean> => {
    return this._userManager.getUser()
      .then(user => {
        if (this._user !== user) {
          this._loginChangedSubject.next(this.checkUser(user));
        }
        this._user = user;

        return this.checkUser(user);
      })
  }
  private checkUser = (user: User): boolean => {
    return !!user && !user.expired;
  }
  public finishLogin = (): Promise<User> => {
    return this._userManager.signinRedirectCallback()
      .then(user => {
        this._user = user;
        this._loginChangedSubject.next(this.checkUser(user));
        return user;
      })
  }
  public logout = () => {
    this._userManager.signoutRedirect();
  }
  public finishLogout = () => {
    this._user = null;
    this._loginChangedSubject.next(false);
    return this._userManager.signoutRedirectCallback();
  }
  public getAccessToken = (): Promise<string> => {
    return this._userManager.getUser()
      .then(user => {
        return !!user && !user.expired ? user.access_token : null;
      })
  }
  GetRolebyToken(token: any) {
    let _token = token.split('.')[1];
    this.tokenresp = JSON.parse(atob(_token))
    return this.tokenresp.role;
  }

  GetUserIdByToken(token: any) {
    let _token = token.split('.')[1];
    this.tokenresp = JSON.parse(atob(_token));
    return this.tokenresp.sub;
  }

  public GetUserId = (): Promise<any> => {
    return this._userManager.getUser()
    .then(user => {
      return this.GetUserIdByToken(user.access_token);
    });
  }

  public checkIfUserIsAdmin = (): Promise<boolean> => {
    return this._userManager.getUser()
      .then(user => {
        return this.GetRolebyToken(user.access_token) == 'Admin';
      })
  }
  public checkIfUserIsManager = (): Promise<boolean> => {
    return this._userManager.getUser()
      .then(user => {
        return this.GetRolebyToken(user.access_token) == 'Management';
      })
  }
  public checkIfUserIsFarmaceut = (): Promise<boolean> => {
    return this._userManager.getUser()
      .then(user => {
        return this.GetRolebyToken(user.access_token) == 'Farmaceut';
      })
  }
  public checkIfUserIsLjekar = (): Promise<boolean> => {
    return this._userManager.getUser()
      .then(user => {
        return this.GetRolebyToken(user.access_token) == 'Ljekar';
      })
  }

  public checkIfUserIsPacijent = (): Promise<boolean> => {
    return this._userManager.getUser()
      .then(user => {
        return this.GetRolebyToken(user.access_token) == 'Pacijent';
      })
  }

  public checkIfUserIsAsistent = (): Promise<boolean> => {
    return this._userManager.getUser()
      .then(user => {
        return this.GetRolebyToken(user.access_token) == 'Asistent';
      })
  }

  public checkIfUserIsTehnicar = (): Promise<boolean> => {
    return this._userManager.getUser()
      .then(user => {
        return this.GetRolebyToken(user.access_token) == 'Tehnicar';
      })
  }
}
