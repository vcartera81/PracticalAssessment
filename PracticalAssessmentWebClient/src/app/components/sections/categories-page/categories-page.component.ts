import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Subscription } from 'rxjs';
import ICategory from 'src/app/models/ICategory';
import { CategoryService } from 'src/app/services/category.service';
import GlobalEvents from 'src/app/services/GlobalEvents';
import { CategoryEditorComponent } from '../../shared/category-editor/category-editor.component';

@Component({
  selector: 'app-categories-page',
  templateUrl: './categories-page.component.html',
  styleUrls: ['./categories-page.component.css']
})
export class CategoriesPageComponent implements OnInit {

  constructor(
    private readonly categoryService: CategoryService,
    private readonly dialog: MatDialog) { }

  public allCategories: Array<ICategory>;
  public subscriptions = new Array<Subscription>();

  public async ngOnInit() {
    this.allCategories = await this.categoryService.getAll();

    this.subscriptions.push(GlobalEvents.onCategoryAdded.subscribe((c: ICategory) => this.onCategoryAdded(c)));
  }

  public async onCategoryDeleteRequested(categoryId: number) {
    await this.categoryService.delete(categoryId);

    const matchingCategoryIndex = this.allCategories.findIndex(_ => _.id === categoryId);
    if(matchingCategoryIndex !== -1)
      this.allCategories.splice(matchingCategoryIndex, 1);
  }

  public onAddNewCategoryRequested() {
    this.dialog.open(CategoryEditorComponent, {
      width: '600px',
      data: null
    });
  }

  private onCategoryAdded(category: ICategory) {
    this.allCategories.push(category);
  }
}
