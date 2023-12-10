import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-uputnice-pacijenta',
  templateUrl: './uputnice-pacijenta.component.html',
  styleUrls: ['./uputnice-pacijenta.component.css']
})
export class UputnicePacijentaComponent implements OnInit {

  podaci: any;
  pacijentId: any;

  constructor(private httpKlijent: HttpClient, private url: EnvironmentUrlService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.parent.params.subscribe(params => {
      this.pacijentId = params['id'];
      this.loadData();
    });
  }

  loadData() {
    this.httpKlijent.get(this.url.urlAddress + '/Uputnica/GetById/' + this.pacijentId)
      .subscribe((result: any) => {
        this.podaci = result;
      });
  }

}
