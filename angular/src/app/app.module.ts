import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import {MAT_FORM_FIELD_DEFAULT_OPTIONS, MatFormFieldModule} from '@angular/material/form-field';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

import { AppComponent } from './app.component';
import { MenuComponent } from './menu/menu.component';
import { SigninRedirectCallbackComponent } from './signin-redirect-callback/signin-redirect-callback.component';
import { SignoutRedirectCallbackComponent } from './signout-redirect-callback/signout-redirect-callback.component';
import { LijekoviComponent } from './components/lijekovi/lijekovi.component';
import { AuthInterceptorService } from "./shared/services/auth-interceptor.service";
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { PrivacyComponent } from './privacy/privacy.component';
import { LijekoviEditComponent } from "./components/lijekovi/lijekovi-edit/lijekovi-edit.component";
import { LijekoviAddComponent } from './components/lijekovi/lijekovi-add/lijekovi-add.component';
import { AboutComponent } from './about/about.component';
import { HomeComponent } from './home/home.component';
import { DepartmentsComponent } from './departments/departments.component';
import { DoctorsComponent } from './doctors/doctors.component';
import { ContactComponent } from './contact/contact.component';
import { PacijentiComponent } from './pacijenti/pacijenti.component';
import { PacijentiAddComponent } from './pacijenti/pacijenti-add/pacijenti-add.component';
import { PacijentiEditComponent } from './pacijenti/pacijenti-edit/pacijenti-edit.component';
import { NgToastModule } from 'ng-angular-popup';
import { ManagementComponent } from './components/management/management.component';
import { DatePipe } from '@angular/common';
import { MainComponent } from './main/main.component';
import { HeaderComponent } from './header/header.component';
import { KartonPacijentaComponent } from './karton-pacijenta/karton-pacijenta.component';
import { NalaziPacijentaComponent } from './nalazi-pacijenta/nalazi-pacijenta.component';
import { UputnicePacijentaComponent } from './uputnice-pacijenta/uputnice-pacijenta.component';
import { ReceptiComponent } from './recepti/recepti.component';
import { ReceptiEditComponent } from './recepti/recepti-edit/recepti-edit.component';
import { TerminiComponent } from './termini/termini.component';
import { ManagementAddComponent } from './components/management/management-add/management-add.component';
import { ManagementEditComponent } from './components/management/management-edit/management-edit.component';
import { LjekariComponent } from './uposlenici/ljekari/ljekari.component';
import { AsistentiComponent } from './uposlenici/asistenti/asistenti.component';
import { TehnicariComponent } from './uposlenici/tehnicari/tehnicari.component';
import { FarmaceutiComponent } from './uposlenici/farmaceuti/farmaceuti.component';
import { AsistentDetaljiComponent } from './uposlenici/asistenti/asistent-detalji/asistent-detalji.component';
import { FarmaceutDetaljiComponent } from './uposlenici/farmaceuti/farmaceut-detalji/farmaceut-detalji.component';
import { TehnicarDetaljiComponent } from './uposlenici/tehnicari/tehnicar-detalji/tehnicar-detalji.component';
import { LjekarDetaljiComponent } from './uposlenici/ljekari/ljekar-detalji/ljekar-detalji.component';
import { TerminiPregledComponent } from './components/termini-pregled/termini-pregled.component';
import { FullCalendarModule } from '@fullcalendar/angular';
import { TerminAddComponent } from './components/termini-pregled/termin-add/termin-add.component';
import { TerminDetailComponent } from './components/termini-pregled/termin-detail/termin-detail.component';
import { ConfirmDialogComponent } from './confirm-dialog/confirm-dialog.component';
import { GlavnaPlocaComponent } from './components/glavna-ploca/glavna-ploca.component';
import { OsobljeComponent } from './components/management/osoblje/osoblje.component';
import { OsobljeEditComponent } from './components/management/osoblje/osoblje-edit/osoblje-edit.component';
import { OsobljeAddComponent } from './components/management/osoblje/osoblje-add/osoblje-add.component';
import { LijekoviInfoComponent } from './components/lijekovi/lijekovi-info/lijekovi-info.component';
import { TerminiInfoComponent } from './termini/termini-info/termini-info.component';
import { ReceptInfoComponent } from './recepti/recept-info/recept-info.component';
import { ReceptAddComponent } from './recepti/recept-add/recept-add.component';
import { ObavijestiComponent } from './components/obavijesti/obavijesti.component';

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}

const routes: Routes = [
  { path: 'signin-callback', component: SigninRedirectCallbackComponent },
  { path: 'signout-callback', component: SignoutRedirectCallbackComponent },
  { path: 'lijekovi', component: LijekoviComponent },
  { path: 'pacijenti', component: PacijentiComponent },
  { path: 'unauthorized', component: UnauthorizedComponent },
  { path: 'privacy', component: PrivacyComponent },
  { path: 'home', component: HomeComponent },
  { path: 'about', component: AboutComponent },
  { path: 'departments', component: DepartmentsComponent },
  {
    path: 'doctors', component: DoctorsComponent,
    children: [
      { path: '', redirectTo: 'ljekari', pathMatch: 'full' },
      { path: 'ljekari', component: LjekariComponent },
      { path: 'asistenti', component: AsistentiComponent },
      { path: 'tehnicari', component: TehnicariComponent },
      { path: 'farmaceuti', component: FarmaceutiComponent },
    ]
  },
  { path: 'contact', component: ContactComponent },
  { path: 'management', component: ManagementComponent },
  { path: 'osoblje/:id', component: OsobljeComponent },
  {
    path: 'karton-pacijenta/:id', component: KartonPacijentaComponent,
    children: [
      { path: '', redirectTo: 'nalazi', pathMatch: 'full' },
      { path: 'nalazi', component: NalaziPacijentaComponent },
      { path: 'uputnice', component: UputnicePacijentaComponent },
      { path: 'recepti', component: ReceptiComponent },
      { path: 'termini', component: TerminiComponent },
    ]
  },
  { path: 'termini-pregled', component: TerminiPregledComponent },
  { path: 'glavna-ploca', component: GlavnaPlocaComponent },
  { path: 'obavijesti', component: ObavijestiComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' }
];
@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    SigninRedirectCallbackComponent,
    SignoutRedirectCallbackComponent,
    LijekoviComponent,
    UnauthorizedComponent,
    PrivacyComponent,
    LijekoviEditComponent,
    LijekoviAddComponent,
    HomeComponent,
    AboutComponent,
    DepartmentsComponent,
    DoctorsComponent,
    ContactComponent,
    PacijentiComponent,
    PacijentiAddComponent,
    PacijentiEditComponent,
    ManagementComponent,
    MainComponent,
    HeaderComponent,
    KartonPacijentaComponent,
    NalaziPacijentaComponent,
    UputnicePacijentaComponent,
    ReceptiComponent,
    ReceptiEditComponent,
    TerminiComponent,
    ManagementAddComponent,
    ManagementEditComponent,
    AsistentiComponent,
    LjekariComponent,
    TehnicariComponent,
    FarmaceutiComponent,
    AsistentDetaljiComponent,
    FarmaceutDetaljiComponent,
    TehnicarDetaljiComponent,
    LjekarDetaljiComponent,
    TerminiPregledComponent,
    TerminAddComponent,
    TerminDetailComponent,
    ConfirmDialogComponent,
    GlavnaPlocaComponent,
    OsobljeComponent,
    OsobljeEditComponent,
    OsobljeAddComponent,
    LijekoviInfoComponent,
    TerminiInfoComponent,
    ReceptInfoComponent,
    ReceptAddComponent,
    ObavijestiComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(routes, { enableTracing: true }),
    FormsModule,
    ReactiveFormsModule,
    NgToastModule,
    FullCalendarModule,
    MatFormFieldModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    })
  ],
  providers: [
    DatePipe,
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptorService, multi: true },
    {provide: MAT_FORM_FIELD_DEFAULT_OPTIONS, useValue: {appearance: 'outline'}},
    HttpClient
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
