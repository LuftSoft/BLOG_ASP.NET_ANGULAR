import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { APIService } from 'src/app/services/API.service';
import { DataService } from 'src/app/services/Data.service';

@Component({
  selector: 'app-profile-user',
  templateUrl: './profile-user.component.html',
  styleUrls: ['./profile-user.component.css']
})
export class ProfileUserComponent implements OnInit {

  id: any
  user: any
  constructor(private api: APIService, private msg: DataService, private route: ActivatedRoute
    , public data: DataService, private router: Router) {
    this.route.params.subscribe(p => this.id = p.id);
  }

  ngOnInit(): void {
    this.api.get(`${this.msg.URL}/user/detail/${this.id}`)
      .subscribe(data => { this.user = data['payload']; })
  }

  logout() {
    this.data.User = null;
    localStorage.setItem('user', 'null')
    this.data.setSuccess("Logout success!")
    this.router.navigateByUrl('/post/list', { skipLocationChange: true })
      .then(() => { this.router.navigate(['/']); })
  }

}
