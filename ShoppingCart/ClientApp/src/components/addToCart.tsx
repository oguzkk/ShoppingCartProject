import React, { useState } from "react";
import { IAddToCartProps } from "./models/interfaces";

export const AddToCart = (props: IAddToCartProps) => {
  const [quantity, setQuantity] = useState(1);
  return (
    <div className="addToCart">
      <div className="addToCartQuantityWrapper">
        <button
          className="addToCartIncrease"
          disabled={quantity >= props.product.stockQuantity}
          onClick={() => {
            setQuantity(quantity + 1);
          }}
        >
          +
        </button>
        <button
          className="addToCartDecrease"
          disabled={quantity <= 1}
          onClick={() => {
            setQuantity(quantity - 1);
          }}
        >
          -
        </button>
        <div>{"Adet: " + quantity}</div>
      </div>
      <button
        className="addToCartButton"
        disabled={quantity < 1}
        onClick={() => {
          props.updateCart(quantity);
          setQuantity(quantity == props.product.stockQuantity ? 0 : 1);
        }}
      >
        Sepete Ekle
      </button>
    </div>
  );
};
