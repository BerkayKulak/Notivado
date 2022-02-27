import { Component, Input, OnInit } from '@angular/core';
import { Work } from '../Model';
import { ProductService } from '../product.service';

@Component({
  selector: 'work-details',
  templateUrl: './work-details.component.html',
  styleUrls: ['./work-details.component.css'],
})
export class ProductDetailsComponent implements OnInit {
  @Input() product: Work;
  @Input() products: Work[];

  constructor(private productService: ProductService) {}

  ngOnInit(): void {}

  addProduct(id, name: string, definition:string, isCompleted: boolean) {
    const p = new Work(id, name, definition, isCompleted);
    this.productService.updateProduct(p).subscribe((result) => {
      this.products.splice(
        this.products.findIndex((x) => x.id == p.id),
        1,
        p
      );
    });
    this.product = null;
  }
}
