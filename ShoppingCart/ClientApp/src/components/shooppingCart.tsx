import React, { useState } from "react";
import { IShoppingCartProps } from "./models/interfaces";
import { CartItemList } from "./cartItemList";

export const ShoppingCart = (props: IShoppingCartProps) => {
  const [couponCode, setCouponCode] = useState("");

  return (
    <div className="shoppingCart">
      <div className={"shoppingCartHeader"}>Sepet</div>
      <CartItemList
        cartItems={props.cartData?.cartPrintItems ?? []}
      ></CartItemList>
      <button className="campaignButton" onClick={props.applyDiscounts}>
        Kampanyaları Uygula
      </button>
      <input
        className="couponInput"
        disabled={!props.couponButtonEnabled}
        onChange={(event: React.ChangeEvent<HTMLInputElement>) => {
          setCouponCode(event.target.value);
        }}
      ></input>
      <button
        className="couponButton"
        disabled={!props.couponButtonEnabled}
        onClick={() => {
          props.applyCoupon(couponCode);
        }}
      >
        Kupon Kodunu Kullan
      </button>
      <div className={"amountWrapper"}>
        <span>Toplam Tutar: {props.cartData?.totalAmount ?? 0} TL</span>
        <span>
          Kupon İndirim Tutarı: {props.cartData?.couponDiscountAmount ?? 0} TL
        </span>
        <span>
          Kampanya İndirim Tutarı: {props.cartData?.campaignDiscountAmount ?? 0}{" "}
          TL
        </span>
        <span>
          İndirimler Sonrası Toplam Tutar:{" "}
          {props.cartData?.totalAmountAfterDiscounts ?? 0} TL
        </span>
        <span>Kargo Tutarı: {props.cartData?.deliveryCost ?? 0} TL</span>
      </div>
    </div>
  );
};
