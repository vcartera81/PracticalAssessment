import { Component, OnInit } from '@angular/core';
import ICategory from 'src/app/models/ICategory';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-categories-page',
  templateUrl: './categories-page.component.html',
  styleUrls: ['./categories-page.component.css']
})
export class CategoriesPageComponent implements OnInit {

  constructor(private readonly categoryService: CategoryService) { }

  public allCategories: Array<ICategory>;

  public async ngOnInit() {
    this.allCategories = await this.categoryService.getAll();
  }

  public onCategoryDeleteRequested(categoryId: number) {

  }
}
