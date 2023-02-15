import { Injectable } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';


@Injectable({
  providedIn: 'root'
})
export class FormService {

  constructor() { }

  FnameFormControl = new FormControl('', [Validators.required]);
  LnameFormControl = new FormControl('', [Validators.required]);
  TZformControl = new FormControl('', [Validators.required, Validators.pattern('[0-9]{9}')]);
  formControl = new FormControl('', [Validators.required]);

  CnameFormControls: FormControl[] = [];
  CTZFormControls: FormControl[] = [];

}
