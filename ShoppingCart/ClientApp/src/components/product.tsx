import React, { useState } from "react";
import { IProductProps } from "./models/interfaces";
import { AddToCart } from "./addToCart";

export const Product = (props: IProductProps) => {
  const [stockInCart, setStockInCart] = useState(0);

  const updateStock = (addedToCart: number) => {
    setStockInCart(stockInCart + addedToCart);
  };

  const updateCart = (addeedToCart: number) => {
    props.updateCart(addeedToCart, props.product);
    updateStock(addeedToCart);
  };
  return (
    <div className="product">
      <div className="productTitle">{props.product.title}</div>
      <div className="productImage">
        <img src={props.product.imageURL}></img>
      </div>
      <div className="productPrice">
        {"Fiyat: " + props.product.price + " TL"}
      </div>
      <AddToCart
        product={{
          ...props.product,
          stockQuantity: props.product.stockQuantity - stockInCart
        }}
        updateCart={updateCart}
      ></AddToCart>
      <div className="productStock">
        {"Stok: " + (props.product.stockQuantity - stockInCart) + " Adet"}
      </div>
    </div>
  );
};
