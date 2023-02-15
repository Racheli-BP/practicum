import { Component, inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { Subscription } from 'rxjs';
import { HealthFundService } from '../services/health-fund.service';
import { Person } from '../Models/person';
import { PersonService } from '../services/person.service';
import { Child } from '../Models/child';
import { FormService } from '../services/form.service';
import { ChildService } from '../services/child.service';
import { GenderService } from '../services/gender.service';
import { Router } from '@angular/router';
import swal from 'sweetalert';
import { NgFor } from '@angular/common';

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

  // form-controllers for validation
  FnameFormControl = this.formSer.FnameFormControl;
  LnameFormControl = this.formSer.LnameFormControl;
  TZformControl = this.formSer.TZformControl;
  formControl = this.formSer.formControl;
  CnameFormControls: FormControl[] = this.formSer.CnameFormControls;
  CTZFormControls: FormControl[] = this.formSer.CTZFormControls;


  constructor(public personService: PersonService, public healthFundSer: HealthFundService,
    public formSer: FormService, public childSer: ChildService, public genderSer: GenderService, public router: Router) { }

  ngOnInit(): void {
    this.sub = this.personService.currentUser.subscribe(suc => { this.current = suc; })
    this.sub2 = this.personService.children.subscribe(suc => { this.children = suc; })
  }

  public async save() {
    (await this.personService.addPerson(this.current)).subscribe({
      next: (suc) => {
        this.childSer.addChildren(this.children, suc.id);
        this.personService.currentUser.next(new Person(0, null, null, null, null, 0, 0));
        this.personService.children.next([]);
        this.formSer.CnameFormControls = [];
        this.formSer.CTZFormControls = [];
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
    this.CnameFormControls.push(new FormControl('', [Validators.required]));
    this.CTZFormControls.push(new FormControl('', [Validators.required, Validators.pattern('[0-9]{9}')]));
  }

  cancel() {
    this.personService.currentUser.next(new Person(0, null, null, null, null, 0, 0));
    this.personService.children.next([]);
  }

}