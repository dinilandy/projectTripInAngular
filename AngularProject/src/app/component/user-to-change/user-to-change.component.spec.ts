import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserToChangeComponent } from './user-to-change.component';

describe('UserToChangeComponent', () => {
  let component: UserToChangeComponent;
  let fixture: ComponentFixture<UserToChangeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UserToChangeComponent]
    });
    fixture = TestBed.createComponent(UserToChangeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
