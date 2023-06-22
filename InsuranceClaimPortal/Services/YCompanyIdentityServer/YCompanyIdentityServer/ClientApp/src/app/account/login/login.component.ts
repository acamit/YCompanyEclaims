/* eslint-disable @typescript-eslint/no-explicit-any */
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm = this.formBuilder.group({
    userName: ['', Validators.required],
    password: ['', Validators.required],
    returnUrl: [this.route.snapshot.queryParamMap.get('returnUrl')]
  })

  constructor(private formBuilder: FormBuilder, private http: HttpClient, private route: ActivatedRoute) { }

  onSubmit() {
    this.http.post('/api/login', this.loginForm.value)
      .subscribe({
        next: (response:any) => {
          window.location.href = response.returnUrl;
        },
        error: () => {
          this.loginForm.reset();
        }
      });
  }
}
