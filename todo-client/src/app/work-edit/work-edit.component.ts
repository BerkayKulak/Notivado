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
    id: new FormControl(''),
    name: new FormControl(''),
    definition: new FormControl(''),
    isCompleted: new FormControl(''),
  });

  work: Work;

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
          id: new FormControl(result['data']['id']),
          name: new FormControl(result['data']['name']),
          definition: new FormControl(result['data']['definition']),
          isCompleted: new FormControl(result['data']['isCompleted']),
        });
      });
  }

  workById(id: number) {
    //Work =  this.productService.getProductById(id);
  }

  updateWork() {
    this.productService.updateWork(this.editWork.value).subscribe((result) => {
      console.log('success');
    });
  }
}
