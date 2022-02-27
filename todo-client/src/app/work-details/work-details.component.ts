import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Work, WorkAdd } from '../Model';
import { ProductService } from '../product.service';

@Component({
  selector: 'work-details',
  templateUrl: './work-details.component.html',
  styleUrls: ['./work-details.component.css'],
})
export class ProductDetailsComponent implements OnInit {
  @Input() product: WorkAdd;
  @Input() products: Work[];

  constructor(private productService: ProductService,private router: Router) {}

  ngOnInit(): void {
    
  }

  addProduct(name: string, definition: string, isCompleted: boolean) {
    const p = new WorkAdd(name, definition, isCompleted);
    this.productService.addProduct(p).subscribe((result) => {
      console.log(p);
    });
    this.product = null;
  }

  return(){
    this.router.navigate(['/todo']);
  }
}
