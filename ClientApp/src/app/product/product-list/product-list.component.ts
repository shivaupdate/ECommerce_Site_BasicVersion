import { Component, OnInit } from "@angular/core";
import { ProductsService } from "../../services/product.service";
import { userSelectedQuantity } from "../models/userSelectedQuantity";

@Component({
  selector: "app-product-list",
  templateUrl: "./product-list.component.html",
  styleUrls: ["./product-list.component.css"]
})
export class ProductListComponent implements OnInit {
  public productList = [];
  public userSelectedQuantityList: userSelectedQuantity[] = [];
  public totalPrice = 0;
  public totalDiscountedPrice = 0;
  constructor(public productService: ProductsService) { }

  ngOnInit() {
    this.productService.getProductlist().subscribe(result => {
      this.productList = result;
    }, error => console.error(error));
  }

  UpdateQuantityChange(itemDetail: userSelectedQuantity) {

    this.productService.addtoCart(itemDetail).subscribe(res => {
      itemDetail = res;
      const index = this.userSelectedQuantityList.findIndex(x => x.name === itemDetail.name);
      this.addOrUpdateItem(index, itemDetail);
      this.totalPrice = this.getTotalPrice();
      this.totalDiscountedPrice = this.getDiscountedTotalPrice();

    });



  }
  private getTotalPrice(): number {
    return this.userSelectedQuantityList
      .map(item => item.itemPrice)
      .reduce((prev, curr) => prev + curr, 0);
  }
  private getDiscountedTotalPrice(): number {
    return this.userSelectedQuantityList
      .map(item => item.discountedPrice)
      .reduce((prev, curr) => prev + curr, 0);
  }

  public addOrUpdateItem(index: number, itemDetail: userSelectedQuantity) {
    if (index > -1) {
      this.userSelectedQuantityList[index].quantity = itemDetail.quantity;
      this.userSelectedQuantityList[index].itemPrice = itemDetail.quantity * itemDetail.itemPrice;
      this.userSelectedQuantityList[index].discountedPrice = itemDetail.discountedPrice;
    } else {
      this.userSelectedQuantityList.push({
        quantity: itemDetail.quantity,
        itemPrice: itemDetail.quantity * itemDetail.itemPrice,
        name: itemDetail.name,
        discountedPrice: itemDetail.discountedPrice
      });
    }
  }
}
