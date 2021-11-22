## C#寫作風格

1. Function 命名

   1. 動詞在前,副詞在後
   2. 名稱大駝峰
   3. 參數小駝峰
   4. 例如:GetProductAsync

2. Class 命名

   1. 名稱大寫 例如 Class Product
   2. 屬性名稱，大駝峰

3. 變數 命名

   1. 動詞在前,副詞在後
   2. 小駝峰 例如 getProduct
   3. 不能寫 magic number,除了 lumbda 以及迴圈系列

4. 建構子 命名

   1. 參數小駝峰
   2. 變數"\_"+小駝峰

5. 與前端溝通物件(Ex:Session) 命名

## C#縮寫

| 英文全名 | 縮寫 |
| -------- | ---- |
| Function | Fun  |
| Password | Key  |
| Request  | Req  |
| Response | Rsp  |

## JavaScript 寫作風格

1. Function 命名

   1. 動詞在前,副詞在後
   2. 名稱大駝峰
   3. 參數小駝峰
   4. 例如:GetProductAsync

2. Class 命名

   1. 名稱大寫 例如 Class Product
   2. 屬性名稱，大駝峰

3. 變數 命名

   1. 動詞在前,副詞在後
   2. 小駝峰 例如 getProduct
   3. 不能寫 magic number,除了 lumbda,for 迴圈

4. 建構子 命名

   1. 參數大駝峰
   2. 變數"\_"+小駝峰

5. 型別使用
   1. var 只用使用在全域
   2. let 涵式內
   3. const 不會在改變

## JavaScript 縮寫

| 英文全名 | 縮寫 |
| -------- | ---- |
| Request  | Req  |
| Response | Rsp  |

## Vue 寫作風格

1. Option Function 命名

```javascript
data:function () {
	return {
		products: [],
		tempProduct: {},
		message: 'hello vue',
		method: ''
	}
}
```

2. Component 命名
   變數小駝峰

```javascript
import modalProduct from '/StaticFiles/Vue/Components/ModalProduct.js'
```

html 都小寫

```html
<modal-product
  ref="modalProduct"
  v-bind:method="method"
  v-bind:temp-product="tempProduct"
  v-on:emit-product="changeProduct"
></modal-product>
```

## Commit 名稱

拉 notion 的 task 名稱當作 Commit 名稱
