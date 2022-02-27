export class Model {

  products: Array<Work>;

  constructor() {
    // this.products = [
    //   new Product(1, 'samsung s5', 2000, false),
    //   new Product(2, 'samsung s6', 3000, true),
    //   new Product(3, 'samsung s7', 4000, false),
    //   new Product(4, 'samsung s8', 5000, true),
    //   new Product(5, 'samsung s9', 6000, true),
    // ];
  }
}

export class Work {
  id: number;
  name: string;
  definition: string;
  isCompleted: boolean;

  constructor(id: number, name: string, definition: string, isCompleted: boolean) {
    this.id = id;
    this.name = name;
    this.definition = definition;
    this.isCompleted = isCompleted;
  }
}


export class WorkAdd {
 
  name: string;
  definition: string;
  isCompleted: boolean;

  constructor( name: string, definition: string, isCompleted: boolean) {
    this.name = name;
    this.definition = definition;
    this.isCompleted = isCompleted;
  }
}
