mod models;

use models::Hand;

/// Given a list of poker hands, return a list of those hands which win.
///
/// Note the type signature: this function should return _the same_ reference to
/// the winning hand(s) as were passed in, not reconstructed strings which happen to be equal.
pub fn winning_hands<'a>(hands_input: &[&'a str]) -> Vec<&'a str> {
  let hands = hands_input.map(Hand::from).collect();
}
