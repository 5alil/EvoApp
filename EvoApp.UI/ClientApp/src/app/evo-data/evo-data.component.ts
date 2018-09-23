import { Component, Inject, OnInit, AfterViewInit } from '@angular/core';
import { EvoServices } from '../shared-services/shared-services';
import { EvoDto } from '../models/models';



@Component({
  selector: 'app-evo-data',
  templateUrl: './evo-data.component.html'
})
export class EvoDataComponent implements OnInit {
  public evos: EvoDto[];
  public showEdit: boolean;
  public evoItem : EvoDto;

  constructor(private _evoServices: EvoServices) {
  }

  ngOnInit() {
    this.RefreshEvos();
  }

  RefreshEvos() {
    this.evos = [];
    this._evoServices.getAllEvos().subscribe(result => {
      this.evos = result;
    }, error => console.error(error));
  }
  DeleteEvo = function (evo: EvoDto) {
    this._evoServices.DeleteEvo(evo.id).subscribe(result => {
      if (result)
        this.RefreshEvos();
    }, error => console.error(error));
  }
  SaveEvo = function () {
    if (this.evoItem && this.evoItem.name && this.evoItem.name != "") {
      this._evoServices.InsertEvo(this.evoItem).subscribe(result => {
        this.RefreshEvos();
        this.showEdit = !this.showEdit;
      }, error => console.error(error));
    } else
      alert("Please Insert Name!!!")
  }
  ShowEditing = function () {
    this.showEdit = !this.showEdit;
    this.evoItem = new EvoDto();
  }
  
}


