import { Component, inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { Subscription } from 'rxjs';
import { HealthFundService } from '../services/health-fund.service';
import { Person } from '../Models/person';
import { PersonService } from '../services/person.service';
import { Child } from '../Models/child';
import { ChildService } from '../services/child.service';
import { GenderService } from '../services/gender.service';
import { Router } from '@angular/router';
import swal from 'sweetalert';
import * as XLSX from 'xlsx';
import { Gender } from '../Models/gender';
import { HealthFund } from '../Models/health-fund';


@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class FormComponent implements OnInit {

  current: Person;
  children: Child[];
  sub: Subscription = new Subscription;
  sub2: Subscription = new Subscription;

  constructor(public personService: PersonService, public healthFundSer: HealthFundService,
    public childSer: ChildService, public genderSer: GenderService, public router: Router) { }

  ngOnInit(): void {
    this.sub = this.personService.currentUser.subscribe(suc => { this.current = suc; })
    this.sub2 = this.personService.children.subscribe(suc => { this.children = suc; })
  }

  public async save() {
    (await this.personService.addPerson(this.current)).subscribe({
      next: (suc) => {
        this.childSer.addChildren(this.children, suc.id);
        this.exportexcel();
        this.personService.currentUser.next(new Person(0, null, null, null, null, 0, 0));
        this.personService.children.next([]);
        swal({ title: "נרשמת בהצלחה!", icon: "success", });
        this.router.navigate(["instructions"]);
      },
      error: (err) => {
        console.log(err);
        alert("שגיאה: " + err.error);
      }
    })
  }

  addChild() {
    this.children.push(new Child(null, null, null, 0));
  }

  cancel() {
    this.personService.currentUser.next(new Person(0, null, null, null, null, 0, 0));
    this.personService.children.next([]);
  }


  exportexcel(): void {
    /* pass here the table id */
    let element = document.getElementById('excel-table');
    const ws: XLSX.WorkSheet = XLSX.utils.table_to_sheet(element);

    /* generate workbook and add the worksheet */
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');

    /* save to file */
    XLSX.writeFile(wb, this.current.firstName + " " + this.current.lastName+".xlsx");
  }
  getCurrentGenderName() {
    let g: Gender;
    if (this.genderSer.genders != undefined)
      g = this.genderSer.genders.find(a => a.id === this.current.genderId);
    return g ? g.name : "";
  }
  getCurrentHFName(){
    let h: HealthFund;
    if (this.healthFundSer.healthFunds != undefined)
      h = this.healthFundSer.healthFunds.find(a => a.id === this.current.healthFundId);
    return h ? h.name : "";
  }

}