package com.bjss.exercise.services

import com.bjss.exercise.domain.Basket
import com.bjss.exercise.domain.Offer
import com.bjss.exercise.domain.Product
import com.bjss.exercise.domain.Rule
import com.bjss.exercise.validation.ProductUnitsValidator
import spock.lang.Specification

class ApplesDiscountSpec extends Specification {

    def "Pricing apples with discount"() {
        given: "I have placed items to basket"
        def milk = new Product() {{
            setName("Milk")
            setPrice(1.30)
            setOffers([] as Set<Offer>)
        }}
        def apples = new Product() {{
            setName("Apples")
            setPrice(1.00)
            setOffers([ new Offer() {{
                setDiscount(10)
                setRules([] as Set<Rule>)
            }}].toSet())
        }}
        def items = [ milk, apples ]
        def basket = Basket.placeItems(items)
        when: "I purchasing items"
        def service = new PurchaseService(new ProductUnitsValidator())
        def receipt = service.purchase(basket)
        then: "discount of 10% should be applied for apples"
        assert !receipt.discounts.isEmpty()
        and:
        assert receipt.getTotal().compareTo(2.20) == 0
        and:
        assert receipt.getSubtotal().compareTo(2.30) == 0
    }
}
