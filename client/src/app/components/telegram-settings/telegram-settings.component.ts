import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { TelegramSetting } from 'src/app/models/telegramSetting';
import { TelegramSettingsService } from 'src/app/services/telegram-settings.service';
import { UpdateSuccessDialogComponent } from './update-success-dialog/update-success-dialog.component';

@Component({
  selector: 'app-telegram-settings',
  templateUrl: './telegram-settings.component.html',
  styleUrls: ['./telegram-settings.component.scss']
})
export class TelegramSettingsComponent implements OnInit {
  tgSettingsArray: TelegramSetting[] = [];
  isLoading = false;
  isEditMode = false;
  displayedColumns: string[] = ['key', 'value', 'actions'];
  tgSettingToEdit: TelegramSetting = {
    id: 0,
    key: '',
    value: '',
  };
  tgSettingsForm = new FormGroup({
    id: new FormControl(0),
    key: new FormControl(''),
    value: new FormControl('', [Validators.required]),
  });


  constructor(private tgSettingsService: TelegramSettingsService, public dialog: MatDialog) {}

  ngOnInit(): void {
    this.isLoading = true;

    setTimeout(() => {
      this.getAll();
      this.isLoading = false;
    }, 1500);
  }

  getAll() {
    this.tgSettingsService.getAll().subscribe(
      (data: TelegramSetting[]) => {
        this.tgSettingsArray = data;
      }
    )
  }

  editTgSetting(tgSetting: {}) {
    this.tgSettingsService.editSetting(tgSetting).subscribe();
  }

  unsetEditMode() {
    this.isEditMode = false;

    this.isLoading = true;

    setTimeout(() => {
      this.getAll();
      this.isLoading = false;
    }, 1500);
  }

  onSubmit(){
    if(this.tgSettingsForm.valid) {
      this.editTgSetting(this.tgSettingToEdit);

      this.unsetEditMode();

      this.openDialog();
    }
  }

  goToEditMode(tgSetting: TelegramSetting){
    this.tgSettingToEdit = tgSetting;
    
    this.isEditMode = true;
  }

  openDialog() {
    const dialogRef = this.dialog.open(UpdateSuccessDialogComponent);

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }
}
