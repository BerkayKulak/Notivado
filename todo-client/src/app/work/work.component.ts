import { Component, OnInit } from '@angular/core';
import { Model, Work } from '../Model';
import { ProductService } from '../product.service';

@Component({
  selector: 'products',
  templateUrl: './work.component.html',
  styleUrls: [
    './work.component.css',
    './assets/vendor/aos/aos.css',
    './assets/vendor/bootstrap/css/bootstrap.min.css',
    './assets/vendor/bootstrap/css/bootstrap.min.css',
    './assets/vendor/swiper/swiper-bundle.min.css',
    './assets/vendor/remixicon/remixicon.css',
    './assets/vendor/glightbox/css/glightbox.min.css',
    './assets/css/style.css',
  ],
})
export class ProductsComponent implements OnInit {
  selectedProduct: Work;
  products: Work[];

  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts() {
    this.productService.getProducts().subscribe((products) => {
      this.products = products.data;
      console.log(this.products);
    });
  }

  onSelectProduct(product: Work) {
    this.selectedProduct = product;
  }

  deleteProduct(product: Work) {
    this.productService.deleteProduct(product).subscribe((p) => {
      this.products.splice(
        this.products.findIndex((p) => p.id == product.id),
        1
      );
    });
  }
}
