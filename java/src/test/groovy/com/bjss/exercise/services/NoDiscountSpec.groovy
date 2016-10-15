package com.bjss.exercise.services

import com.bjss.exercise.domain.Basket
import com.bjss.exercise.domain.Offer
import com.bjss.exercise.domain.Product
import com.bjss.exercise.validation.ProductUnitsValidator
import spock.lang.Specification

class NoDiscountSpec extends Specification {

    def "Buying items with no offer should cost full price"() {
        given: "I have placed products with no offer"
        def milk = new Product() {{
            setName("Milk")
            setPrice(1.30)
            setOffers([] as Set<Offer>)
        }}
        def items = [ milk ]
        def basket = Basket.placeItems(items)
        when: "I buying items"
        def service = new PurchaseService(new ProductUnitsValidator())
        def receipt = service.purchase(basket)
        then: "it should cost me full price"
        assert receipt.discounts.isEmpty()
        and:
        assert receipt.getTotal().compareTo(1.30) == 0
        and:
        assert receipt.getSubtotal().compareTo(1.30) == 0
    }
}
