import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CategoryType } from 'src/app/models/CategoryType';
import ICategory from 'src/app/models/ICategory';
import { CategoryService } from 'src/app/services/category.service';
import GlobalEvents from 'src/app/services/GlobalEvents';

@Component({
  selector: 'app-category-editor',
  templateUrl: './category-editor.component.html',
  styleUrls: ['./category-editor.component.css']
})
export class CategoryEditorComponent implements OnInit {

  constructor(
    private readonly categoryService: CategoryService,
    private readonly dialogRef: MatDialogRef<CategoryEditorComponent>,
    @Inject(MAT_DIALOG_DATA) public inputCategory: ICategory) {
    this.dialogRef.disableClose = true;
  }

  ngOnInit(): void {
  }

  public categoryEditorForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
    type: new FormControl(CategoryType.Outgo, [Validators.required])
  });

  public async onSubmit() {
    const model: ICategory = {
      id: this.inputCategory?.id,
      name: this.categoryEditorForm.controls['name'].value,
      type: this.categoryEditorForm.controls['type'].value
    }

    model.id = await this.categoryService.add(model);

    GlobalEvents.onCategoryAdded.emit(model);
    this.dialogRef.close();
  }

  public cancel() {
    this.dialogRef.close();
  }
}
