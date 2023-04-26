import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { SigninModel } from 'src/app/models/SigninModel';
import { APIService } from 'src/app/services/API.service';
import { DataService } from 'src/app/services/Data.service';

@Component({
  selector: 'app-auth-signin',
  templateUrl: './auth-signin.component.html',
  styleUrls: ['./auth-signin.component.css']
})
export class AuthSigninComponent implements OnInit {
  //goi app component
  @Output() login: EventEmitter<any> = new EventEmitter();
  public payload: SigninModel
  constructor(public api: APIService, public data: DataService, private router: Router) {
    this.payload = new SigninModel("", "");
  }

  ngOnInit(): void {
  }
  signin() {
    this.api.post(`${this.data.URL}/auth/signin`, this.payload)
      .subscribe({
        next: (data) => {
          console.log(data)
          if (data.success === true) {
            this.data.setSuccess("Login success!")
            this.data.User = data.payload.user
            console.log(this.data.User)
            localStorage.setItem("token", data.payload.token);
            localStorage.setItem("user", JSON.stringify(data.payload.user));
            // this.router.navigateByUrl("/", { skipLocationChange: true }).then(() => {
            //   this.router.navigate(['/']);
            // })
            this.router.navigate(['/']);
          }
        },
        error: (error) => {
          console.log(error);
          this.data.message = error.message
        },
        complete: () => { }
      });
  }
} 
