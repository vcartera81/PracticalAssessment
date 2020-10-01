import { Component, OnInit, Input, forwardRef } from '@angular/core';
import { NG_VALUE_ACCESSOR, ControlValueAccessor, NG_VALIDATORS, FormControl, Validator, AbstractControl, ValidationErrors } from '@angular/forms';

@Component({
  selector: 'app-amount-input',
  templateUrl: './amount-input.component.html',
  styleUrls: ['./amount-input.component.css'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => AmountInputComponent),
      multi: true
    },
    {
      provide: NG_VALIDATORS,
      useExisting: forwardRef(() => AmountInputComponent),
      multi: true
    }
  ]
})
export class AmountInputComponent implements OnInit, ControlValueAccessor, Validator {

  constructor() { }

  private _value: number;

  @Input('currency')
  public currency: string;

  public ngOnInit(): void {
    if(!this.currency)
      throw new Error('Currency is a required field!');
  }

  public control: AbstractControl;

  public onChange: any = (newValue: string) => {

  }

  public onTouch: any = () => { }
  public set value(val: number) {
    this._value = val;
    this.onChange(val)
    this.onTouch(val)
  }

  public get value(): number {
    return this._value;
  }

  public writeValue(value: number) {
    this._value = value
  }

  public registerOnChange(fn: any) {
    this.onChange = fn
  }

  public registerOnTouched(fn: any) {
    this.onTouch = fn
  }

  public validate(control: AbstractControl) : ValidationErrors | null {
    this.control = control;
    const error = (key: string) => ({
      [key]: true
    });

    // if (control.value === null || control.value === undefined)
    //   return error('isNull');

    if (isNaN(control.value))
      return error('notANumber');

    if (control.value <= 0)
      return error('zeroOrLess');

    return null;
  }
}