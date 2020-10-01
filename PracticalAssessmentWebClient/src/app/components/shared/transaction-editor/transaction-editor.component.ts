import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import ITransaction from 'src/app/models/ITransaction';

@Component({
  selector: 'app-transaction-editor',
  templateUrl: './transaction-editor.component.html',
  styleUrls: ['./transaction-editor.component.css']
})
export class TransactionEditorComponent implements OnInit {

  constructor(
    private readonly dialogRef: MatDialogRef<TransactionEditorComponent>,
    @Inject(MAT_DIALOG_DATA) public inputTransaction: ITransaction) { 
      dialogRef.disableClose = true;
    }

  ngOnInit(): void {
  }

  public transactionEditorForm = new FormGroup({
    title: new FormControl('', [Validators.required]),
    occuredOn: new FormControl(this.inputTransaction.occuredOn, [Validators.required]),
    category: new FormControl(null, [Validators.required]),
    currency: new FormControl(null, [Validators.required]),
    recipient: new FormControl(null, [Validators.required]),
    amount: new FormControl(null, [Validators.required]),
  });

  public cancel() {
    this.dialogRef.close();
  }

  public onSubmit() {
    
  }

}