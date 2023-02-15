import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Person } from '../Models/person';
import { PersonService } from '../services/person.service';

@Component({
  selector: 'app-instructions',
  templateUrl: './instructions.component.html',
  styleUrls: ['./instructions.component.scss']
})
export class InstructionsComponent implements OnInit {

  sub: Subscription;
  current: Person;

  constructor(public personService: PersonService) { }

  ngOnInit(): void {
    this.sub = this.personService.currentUser.subscribe(suc => {
      this.current = suc;
    })
  }

}
