import { Component, OnInit, HostListener } from '@angular/core';
import { NewsService } from '../shared/news.service';
import { News } from '../shared/news.model';
import { ToastrService } from 'ngx-toastr';
import { AuthenticationService } from '../shared/login.service';

@Component({
  selector: 'news-list',
  templateUrl: './news-list.component.html',
  styles: [],
})
export class NewsListComponent implements OnInit {
  searchText: string = '';
  constructor(public service: NewsService, private toastr: ToastrService, public authService: AuthenticationService) {}

  ngOnInit(): void {
    this.service.refreshList();
  }

  isAdmin(): boolean {
    return !!this.authService.currentUserValue;
  }

  isMyNews(news): boolean {
    return news.userId === this.authService.currentUserValue.id;
  }

  @HostListener('input') oninput() {
    this.searchItems();
  }

  searchItems() {
    console.log(this.searchText);
    this.service.refreshList(this.searchText);
  }
  
  populateForm(selectedRecord: News) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id: number) {
    if (confirm('Are you sure to delete this record?')) {
      this.service.deleteNews(id)
        .subscribe(
          res => {
            this.service.refreshList();
            this.toastr.error("Deleted successfully", 'Payment Detail Register');
          },
          err => { console.log(err) }
        )
    }
  }
}
