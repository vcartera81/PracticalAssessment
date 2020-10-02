import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import IRecipient from 'src/app/models/IRecipient';
import GlobalEvents from 'src/app/services/GlobalEvents';
import { RecipientService } from 'src/app/services/recipient.service';

@Component({
  selector: 'app-recipient-editor',
  templateUrl: './recipient-editor.component.html',
  styleUrls: ['./recipient-editor.component.css']
})
export class RecipientEditorComponent implements OnInit {

  constructor(
    private readonly recipientService: RecipientService,
    private readonly dialogRef: MatDialogRef<RecipientEditorComponent>,
    @Inject(MAT_DIALOG_DATA) public inputRecipient: IRecipient) {
    this.dialogRef.disableClose = true;
  }

  ngOnInit(): void {
  }

  public recipientEditorForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
  });

  public async onSubmit() {
    const model: IRecipient = {
      id: this.inputRecipient?.id,
      name: this.recipientEditorForm.controls['name'].value,
    }

    model.id = await this.recipientService.add(model);

    GlobalEvents.onRecipientAdded.emit(model);
    this.dialogRef.close();
  }

  public cancel() {
    this.dialogRef.close();
  }
}
