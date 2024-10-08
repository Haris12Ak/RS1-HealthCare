/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { TerminiComponent } from './termini.component';

describe('TerminiComponent', () => {
  let component: TerminiComponent;
  let fixture: ComponentFixture<TerminiComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TerminiComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TerminiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
