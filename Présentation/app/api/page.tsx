"use client";
import { Elements } from "@stripe/react-stripe-js";
import { loadStripe } from "@stripe/stripe-js";
import PaymentForm from "@/components/PaymentForm/PaymentForm";
// Make sure to call `loadStripe` outside of a component’s render to avoid
// recreating the `Stripe` object on every render.
const stripePromise = loadStripe(
  "pk_test_51PDRfCCmcbawN1NBdnHE64IMs8Nq42j3Bbz1SiaCW8kG2ZqLZirqtSJuEOPU1mDSv43ghtepQLyhcvDYBz4LUg9C00sfre7Tum"
);

export default function Home() {
  return (
    <Elements stripe={stripePromise}>
      <PaymentForm />
    </Elements>
  );
}