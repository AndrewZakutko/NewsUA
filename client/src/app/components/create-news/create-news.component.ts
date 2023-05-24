import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { NewsService } from 'src/app/services/news.service';
import { CreateNewsDialogComponent } from './create-news-dialog/create-news-dialog.component';

@Component({
  selector: 'app-create-news',
  templateUrl: './create-news.component.html',
  styleUrls: ['./create-news.component.scss']
})
export class CreateNewsComponent implements OnInit {
  newsForm = new FormGroup({
    title: new FormControl('', [Validators.required]),
    subTitle: new FormControl('', [Validators.required]),
    authorName: new FormControl('', [Validators.required]),
    information: new FormControl('', [Validators.required]),
    status: new FormControl('InProcess', [Validators.required]),
    isHot: new FormControl(false, [Validators.required]),
    type: new FormControl('', [Validators.required]),
  });

  constructor(private newsService: NewsService, private router: Router, public dialog: MatDialog) {}

  openDialog() {
    this.dialog.open(CreateNewsDialogComponent);
  }

  ngOnInit(): void {
    
  }

  onSubmit(){
    if(this.newsForm.valid) {
      this.newsService.create(this.newsForm.value).subscribe();
      this.openDialog();
      this.router.navigateByUrl('/');
    }
  }
}
