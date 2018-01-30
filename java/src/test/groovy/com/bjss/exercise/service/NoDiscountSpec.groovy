package com.bjss.exercise.service

import com.bjss.exercise.domain.Basket
import com.bjss.exercise.domain.Offer
import com.bjss.exercise.domain.Product
import com.bjss.exercise.validation.ProductUnitsValidator
import spock.lang.Specification

class NoDiscountSpec extends Specification {

    def 'An items with no offer cost full price'() {
        given: 'Products with no offer'
        def milk = new Product(
            name: 'Milk',
            price: 1.30,
            offers: [] as Set<Offer>
        )
        def basket = Basket.placeItems([milk])

        when: 'I buy items'
        def service = new PurchaseService(new ProductUnitsValidator())
        def receipt = service.purchase basket

        then: 'it cost full price'
        receipt.discounts.empty

        and:
        receipt.total == 1.30

        and:
        receipt.subtotal == 1.30
    }
}
