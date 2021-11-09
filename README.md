## C#寫作風格
1. Funtion 命名
	1. 動詞在前,副詞在後
	2. 名稱大駝峰
	3. 參數大駝峰
	4. 例如:GetProductAsync
	
2. Class 命名
	1. 名稱大寫 例如Class Product
	2. 屬性名稱，大駝峰
	
3. 變數 命名
	1. 動詞在前,副詞在後
	2. 小駝峰 例如getProduct
	3. 不能寫magic number,除了lumbda

4. 建構子 命名
	1. 參數大駝峰
	2. 變數小駝峰
	
## C#縮寫
| 英文全名  |  縮寫 |
| ------------ | ------------ |
|   |   |

## JavaScript寫作風格
1. Funtion 命名
	1. 動詞在前,副詞在後
	2. 名稱大駝峰
	3. 參數大駝峰
	4. 例如:GetProductAsync
	
2. Class 命名
	1. 名稱大寫 例如Class Product
	2. 屬性名稱，大駝峰
	
3. 變數 命名
	1. 動詞在前,副詞在後
	2. 小駝峰 例如getProduct
	3. 不能寫magic number,除了lumbda,for迴圈

4. 建構子 命名
	1. 參數大駝峰
	2. 變數小駝峰

5. 型別使用
	1. var 只用使用在全域
	2. let 涵式內
	3. const 不會在改變

## JavaScript縮寫
| 英文全名  |  縮寫 |
| ------------ | ------------ |
|   |   |

## Vue寫作風格
1. Option Funtion 命名
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
import modalProduct from '/StaticFiles/Vue/Components/ModalProduct.js';
```
html都小寫
```html
<modal-product ref="modalProduct" v-bind:method="method" v-bind:temp-product="tempProduct" v-on:emit-product="changeProduct"></modal-product>
```


## Commit名稱
拉notion的task名稱當作Commit名稱




