import { Component, OnInit } from '@angular/core';
import { NewsService } from 'src/app/shared/news.service';
import { NgForm } from '@angular/forms';
import { News } from 'src/app/shared/news.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'news-form',
  templateUrl: './news-form.component.html',
  styles: [
  ]
})
export class NewsFormComponent implements OnInit {

  constructor(public service: NewsService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
    if (this.service.formData.id == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.postNews().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
      },
      err => { console.log(err); }
    );
  }

  updateRecord(form: NgForm) {
    this.service.putNews().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
      },
      err => { console.log(err); }
    );
  }


  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new News();
  }

}