import React from "react";
import { ICartItemListProps } from "./models/interfaces";
import { CartItem } from "./cartItem";

export const CartItemList = (props: ICartItemListProps) => {
  return (
    <div className="cartItemList">
      {props.cartItems.map((cartItem, index) => {
        return <CartItem key={index} {...cartItem}></CartItem>;
      })}
    </div>
  );
};
