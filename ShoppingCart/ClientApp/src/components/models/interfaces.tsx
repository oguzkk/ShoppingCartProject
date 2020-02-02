export interface IProductListProps {
  productList: IProduct[];
  updateCart: (addedToCart: number, product: IProduct) => void;
}
export interface IProduct {
  id: number;
  title: string;
  imageURL: string;
  price: number;
  stockQuantity: number;
}
export interface ICartItem {
  product: IProduct;
  quantity: number;
  totalAmount: number;
}
export interface ICategory {
  id: number;
  parentCategoryId: number;
  parentCategory: ICategory;
  title: string;
}
export interface ICartPrintItem {
  cartItems: ICartItem[];
  category: ICategory;
}
export interface IShoppingCart {
  cartPrintItems: ICartPrintItem[];
  totalAmount: number;
  campaignDiscountAmount: number;
  couponDiscountAmount: number;
  totalAmountAfterDiscounts: number;
  deliveryCost: number;
}
export interface IMainPageState {
  productList: IProduct[];
  shoppingCart?: IShoppingCart;
}
export interface IAddToCartProps {
  product: IProduct;
  updateCart: (addedToCart: number) => void;
}
export interface IProductProps {
  product: IProduct;
  updateCart: (addedToCart: number, product: IProduct) => void;
}
export interface IShoppingCartProps {
  cartData?: IShoppingCart;
  couponButtonEnabled: boolean;
  applyCoupon: (couponCode: string) => void;
  applyDiscounts: () => void;
}
export interface ICartItemListProps {
  cartItems: ICartPrintItem[];
}
