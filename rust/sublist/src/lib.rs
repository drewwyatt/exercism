#[derive(Debug, PartialEq, Eq)]
pub enum Comparison {
    Equal,
    Sublist,
    Superlist,
    Unequal,
}

pub fn sublist<T: PartialEq>(_first_list: &[T], _second_list: &[T]) -> Comparison {
    if _first_list == _second_list {
        println!("_first_list == _second_list");
        return Comparison::Equal;
    }

    if is_sublist_of(_first_list, _second_list) {
        return Comparison::Sublist;
    }

    if is_sublist_of(_second_list, _first_list) {
        return Comparison::Superlist;
    }

    Comparison::Unequal
}

fn is_sublist_of<T: PartialEq>(list_a: &[T], list_b: &[T]) -> bool {
    let mut is_sublist = false;
    if list_a.len() < list_b.len() {
        for b in 0..list_b.len() {
            if is_sublist {
                break;
            }

            let mut found_error = false;
            for a in 0..list_a.len() {
                if a + b >= list_b.len() || list_a[a] != list_b[a + b] {
                    found_error = true;
                    break;
                }
            }

            is_sublist = !found_error;
        }
    }

    is_sublist
}
