import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PathSegments } from './shared/constants/path-segments';
import { MainPageContentComponent } from './components/main-page/main-page-content/main-page-content.component';
import { EditDeleteNewsComponent } from './components/edit-delete-news/edit-delete-news.component';
import { CreateNewsComponent } from './components/create-news/create-news.component';
import { TableToApproveComponent } from './components/table-to-approve/table-to-approve.component';

const routes: Routes = [
  {
    path: PathSegments.INDEX,
    component: MainPageContentComponent
  },
  {
    path: PathSegments.CORRECT,
    component: EditDeleteNewsComponent
  },
  {
    path: PathSegments.CREATE,
    component: CreateNewsComponent
  },
  {
    path: PathSegments.APPROVE,
    component: TableToApproveComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
