import { Component, Input, OnInit } from '@angular/core';
import { Work } from '../Model';
import { ProductService } from '../product.service';

@Component({
  selector: 'work-form',
  templateUrl: './work-form.component.html',
  styleUrls: ['./work-form.component.css'],
})
export class ProductFormComponent implements OnInit {
  @Input() products: Work[];

  constructor(private productService: ProductService) {}

  ngOnInit(): void {}

  addProduct(name: string, price, isCompleted: boolean) {
    console.log(name);
    console.log(price);
    console.log(isCompleted);

    const p = new Work(0, name, price, isCompleted);
    this.productService.addProduct(p).subscribe((product) => {
      console.log(p);
    });
  }
}
