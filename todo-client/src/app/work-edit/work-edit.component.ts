import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Work, WorkAdd } from '../Model';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-work-edit',
  templateUrl: './work-edit.component.html',
  styleUrls: ['./work-edit.component.css'],
})
export class WorkEditComponent implements OnInit {
  editWork = new FormGroup({
    name: new FormControl(''),
    definition: new FormControl(''),
    isCompleted: new FormControl(''),
  });

  constructor(
    private productService: ProductService,
    private router: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.productService
      .getProductById(this.router.snapshot.params.id)
      .subscribe((result) => {
        console.log(result['data']['name']);
        this.editWork = new FormGroup({
          name: new FormControl(result['data']['name']),
          definition: new FormControl(result['data']['definition']),
          isCompleted: new FormControl(result['data']['isCompleted']),
        });
        console.log(this.editWork.value.name);
      });
  }

  workById(id: number) {
    //Work =  this.productService.getProductById(id);
  }

  updateWork(work: Work) {
    this.productService.updateWork(work).subscribe(() => {
      console.log('başarılı');
    });
  }
}
