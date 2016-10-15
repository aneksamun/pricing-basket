package com.bjss.exercise.services

import com.bjss.exercise.domain.Basket
import com.bjss.exercise.domain.Offer
import com.bjss.exercise.domain.Product
import com.bjss.exercise.domain.Rule
import com.bjss.exercise.validation.ProductUnitsValidator
import spock.lang.Specification

class BreadAndSoapDiscountSpec extends Specification {

    def "Buying 2 tins of soup should give special discount for bread"() {
        given: "I have added items with special offer"
        def soap1 = new Product() {{
            setName("Soup")
            setPrice(0.65)
            setOffers([] as Set<Offer>)
        }}
        def soap2 = new Product() {{
            setName("Soup")
            setPrice(0.65)
            setOffers([] as Set<Offer>)
        }}
        def bread = new Product() {{
            setName("Bread")
            setPrice(0.80)
            setOffers([ new Offer() {{
                setDiscount(50)
                setRules([ new Rule() {{
                    setProduct(soap1)
                    setAmount(2)
                }}] as Set<Rule>)
            }}].toSet())
        }}
        def items = [ soap1, soap2, bread ]
        def basket = Basket.placeItems(items)
        when: "I buying items"
        def service = new PurchaseService(new ProductUnitsValidator())
        def receipt = service.purchase(basket)
        then: "I should get half discount for bread"
        assert !receipt.discounts.isEmpty()
        and:
        assert receipt.getTotal().compareTo(1.70) == 0
        and:
        assert receipt.getSubtotal().compareTo(2.10) == 0
    }
}
