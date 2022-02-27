import { Component, OnInit } from '@angular/core';
import { Work } from '../Model';
import { ProductService } from '../product.service';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class MemberListComponent implements OnInit {

  selectedProduct: Work;
  products: Work[];

  constructor(public authService: AuthService,private productService: ProductService) {}

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
