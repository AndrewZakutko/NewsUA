import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NewsService } from 'src/app/services/news.service';
import { NewsTypesService } from 'src/app/services/news-types.service';
import { NewsType } from 'src/app/models/newsTypes';
import { MatSnackBar } from '@angular/material/snack-bar';

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
  newsTypes: NewsType[] = [];

  constructor(private newsService: NewsService, private router: Router, private newsTypesService: NewsTypesService,
    private snackBar: MatSnackBar) {}

  ngOnInit(): void {
    this.getNewsTypes();
  }

  onSubmit(){
    if(this.newsForm.valid) {
      this.newsService.create(this.newsForm.value).subscribe();
      this.openSnackBar();
      this.router.navigateByUrl('/');
    }
  }

  getNewsTypes() {
    this.newsTypesService.getAll().subscribe(
      (data: NewsType[]) => {
        this.newsTypes = data;
      }
    )
  }

  openSnackBar() {
    this.snackBar.open('News has been added to approve list', 'OK', {
      horizontalPosition: 'right',
      verticalPosition: 'bottom',
    });
  }
}
