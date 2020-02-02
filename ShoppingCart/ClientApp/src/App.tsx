import React, { useEffect, useState } from "react";
import "./App.css";
import { ProductList } from "./components/productList";
import { ShoppingCart } from "./components/shooppingCart";
import { IMainPageState, IProduct } from "./components/models/interfaces";
import axios from "axios";

const App = () => {
  const [state, dispatch] = useState<IMainPageState>({ productList: [] });
  const [couponButtonEnabled, setCouponButtonEnabled] = useState(true);

  useEffect(() => {
    axios("api/Product/Products").then(response => {
      state.productList = response.data;
      dispatch({ productList: response.data });
      printCart();
    });
  }, []);

  const updateCart = (quantity: number, product: IProduct) => {
    axios({
      method: "post",
      url: "api/Cart/AddItem",
      data: {
        product,
        quantity
      }
    }).then(() => {
      printCart();
    });
  };

  const applyCoupon = (couponCode: string) => {
    axios({
      method: "post",
      url: "api/Cart/ApplyCoupon",
      data: {
        couponCode: couponCode
      }
    }).then(response => {
      if (response.data) {
        setCouponButtonEnabled(false);
        printCart();
      }
    });
  };

  const applyDiscounts = () => {
    axios({
      method: "post",
      url: "api/Cart/ApplyDiscounts",
      data: {}
    }).then(response => {
      printCart();
    });
  };

  const printCart = () => {
    axios({
      method: "get",
      url: "api/Cart/Print"
    }).then(response => {
      dispatch({
        shoppingCart: response.data,
        productList: state.productList
      });
    });
  };
  return (
    <div className="main">
      <ProductList
        productList={state.productList}
        updateCart={updateCart}
      ></ProductList>
      <ShoppingCart
        applyDiscounts={applyDiscounts}
        cartData={state.shoppingCart}
        applyCoupon={applyCoupon}
        couponButtonEnabled={couponButtonEnabled}
      ></ShoppingCart>
    </div>
  );
};

export default App;
