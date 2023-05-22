import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
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
    title: new FormControl(''),
    subTitle: new FormControl(''),
    authorName: new FormControl(''),
    information: new FormControl(''),
    status: new FormControl('InProcess'),
    isHot: new FormControl(false),
    type: new FormControl('')
  });

  constructor(private newsService: NewsService, private router: Router, public dialog: MatDialog) {}

  openDialog() {
    const dialogRef = this.dialog.open(CreateNewsDialogComponent);

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

  ngOnInit(): void {
    
  }

  onSubmit(){
    this.newsService.create(this.newsForm.value).subscribe();
    this.openDialog();
    this.router.navigateByUrl('/');
  }
}
