import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { APIService } from 'src/app/services/API.service';

@Component({
  selector: 'app-test-upload',
  templateUrl: './test-upload.component.html',
  styleUrls: ['./test-upload.component.css']
})
export class TestUploadComponent implements OnInit {
  uploadForm: FormGroup
  file: File = null;
  constructor(private api: APIService) {

  }

  ngOnInit(): void {
    this.uploadForm = new FormGroup({
      fileName: new FormControl(null),
      fileUpload: new FormControl(null)
    });
  }
  upload(data) {
    var form = new FormData()
    form.append('fileName', data.fileName)
    form.append('fileUpload', this.file)
    this.api.post("http://localhost:8000/job/upload/image", form)
      .subscribe({
        next: (data) => { console.log(`data: ${data}`) },
        error: (err) => { console.log(`error: ${err.message}`) }
      })
    this.uploadForm.reset();
  }
  changeSelectedFile(fileSelect: any) {
    this.file = <File>fileSelect.target.files[0]
  }
}
