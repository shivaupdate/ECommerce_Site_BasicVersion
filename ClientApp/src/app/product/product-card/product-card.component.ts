import { Component, Output, EventEmitter, OnInit, Input } from "@angular/core";
import { userSelectedQuantity } from "../models/userSelectedQuantity";

@Component({
  selector: "app-product-card",
  templateUrl: "./product-card.component.html",
  styleUrls: ["./product-card.component.css"]
})
export class ProductCardComponent implements OnInit {
  @Input() title: string;
  @Input() imageUrl: string;
  @Input() description: string;
  @Input() price: string;
  @Input() discountedPrice: string;
  
  @Output() QuantityChange = new EventEmitter<userSelectedQuantity>();
  public quantity: number[] = [0, 1, 2, 3, 4, 5, 6];
  public selectedQuantity = 0;
  buttonText ="Add to Cart"
  constructor() {}

  ngOnInit() {}

  public emitUserSelectedProdut(title: string, price: number) {
    if(this.selectedQuantity>0)
    {
      this.buttonText = "Update Cart";
    }
    else{
         this.buttonText = "Add to Cart";
    }
    this.QuantityChange.emit({
      quantity: this.selectedQuantity,
      name: title,
      itemPrice: price,
      discountedPrice:0
    });
  }
}
