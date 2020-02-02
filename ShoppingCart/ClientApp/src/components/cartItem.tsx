import React from "react";
import { ICartPrintItem, ICartItem } from "./models/interfaces";

export const CartItem = (props: ICartPrintItem) => {
  const renderCartItem = (cartItemProducts: ICartItem, key: any) => {
    return (
      <div className="cartItem" key={key}>
        <div className="cartItemTitle">{cartItemProducts.product.title}</div>
        <div className="cartItemImage">
          <img src={cartItemProducts.product.imageURL}></img>
        </div>
        <div className="cartItemPrice">
          {cartItemProducts.quantity +
            " Adet - " +
            cartItemProducts.totalAmount +
            " TL"}
        </div>
      </div>
    );
  };
  return (
    <div className="cartItemWrapper">
      <div className="cartItemCategory">
        {props.category.parentCategory
          ? props.category.parentCategory.title + " => " + props.category.title
          : props.category.title}
      </div>
      {props.cartItems.map((cartItem, index) => {
        return renderCartItem(cartItem, index);
      })}
    </div>
  );
};
