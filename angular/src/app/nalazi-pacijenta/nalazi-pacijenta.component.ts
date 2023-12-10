import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-nalazi-pacijenta',
  templateUrl: './nalazi-pacijenta.component.html',
  styleUrls: ['./nalazi-pacijenta.component.css']
})
export class NalaziPacijentaComponent implements OnInit {

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
    this.httpKlijent.get(this.url.urlAddress + '/Nalaz/GetById/' + this.pacijentId)
      .subscribe((result: any) => {
        this.podaci = result;
      });
  }

}
