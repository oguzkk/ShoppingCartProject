import React from "react";
import { IProductListProps } from "./models/interfaces";
import { Product } from "./product";

export const ProductList = (props: IProductListProps) => {
  return (
    <div className="productList">
      {props.productList.map((productProp, index) => {
        return (
          <Product
            key={index}
            product={productProp}
            updateCart={props.updateCart}
          ></Product>
        );
      })}
    </div>
  );
};
