import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Subscription } from 'rxjs';
import IRecipient from 'src/app/models/IRecipient';
import GlobalEvents from 'src/app/services/GlobalEvents';
import { RecipientService } from 'src/app/services/recipient.service';
import { RecipientEditorComponent } from '../../shared/recipient-editor/recipient-editor.component';

@Component({
  selector: 'app-recipients-page',
  templateUrl: './recipients-page.component.html',
  styleUrls: ['./recipients-page.component.css']
})
export class RecipientsPageComponent implements OnInit, OnDestroy {

  constructor(
    private readonly recipientService: RecipientService,
    private readonly dialog: MatDialog) { }

  public allRecipients: Array<IRecipient>;
  public subscriptions = new Array<Subscription>();

  public async ngOnInit() {
    this.allRecipients = await this.recipientService.getAll();

    this.subscriptions.push(GlobalEvents.onRecipientAdded.subscribe((c: IRecipient) => this.onRecipientAdded(c)));
  }

  public async ngOnDestroy() {
    this.subscriptions.forEach(_ => _.unsubscribe());
  }

  public async onRecipientDeleteRequested(recipientId: number) {
    await this.recipientService.delete(recipientId);

    const matchingRecipientIndex = this.allRecipients.findIndex(_ => _.id === recipientId);
    if(matchingRecipientIndex !== -1)
      this.allRecipients.splice(matchingRecipientIndex, 1);
  }

  public onAddNewRecipientRequested() {
    this.dialog.open(RecipientEditorComponent, {
      width: '600px',
      data: null
    });
  }

  private onRecipientAdded(category: IRecipient) {
    this.allRecipients.push(category);
  }
}