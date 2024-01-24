import { Directive, HostListener, ElementRef, Renderer2, SimpleChanges } from '@angular/core';
import { NgModel } from '@angular/forms';

@Directive({
  selector: '[appPasswordStrength]'
})
export class PasswordStrengthDirective {
  constructor(private el: ElementRef, private renderer: Renderer2, private ngModel: NgModel) { }

  @HostListener('input') onInput() {
    const password = this.ngModel.model as string;
    this.setBorderColor(password);
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes.input) {
      console.log('input changed');
    }
  }

  private setBorderColor(password: string): void {
    // Set border color based on password length
    const borderColor = password.length >= 8 ? 'green' : 'red';
    this.renderer.setStyle(this.el.nativeElement, 'border-color', borderColor);
  }
}
