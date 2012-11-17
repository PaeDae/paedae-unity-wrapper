//
//  PaeDaePrizeDelegate.m
//
//  Created by Miguel Morales on 7/19/12.
//  Copyright (c) 2012 PaeDae Inc. All rights reserved.

#import "PaeDaeSharedPrizeDelegate.h"

@implementation PaeDaeSharedPrizeDelegate

static PaeDaeSharedPrizeDelegate *sharedDelegate = nil;

#pragma mark - static singleton access method
+ (id) sharedDelegate
{
    if (self == [PaeDaeSharedPrizeDelegate class] && !sharedDelegate)
    {
        sharedDelegate = [[PaeDaeSharedPrizeDelegate alloc] init];
    }
    
    return sharedDelegate;
}

#pragma mark - PaeDae Prize Callbacks

- (BOOL)PaeDae_PrizeWillUnload:(UIView *)view
{
    NSLog(@"PRIZE UNLOADED");
    UnitySendMessage("GameObject", "PrizeWillUnload", "This is a test!");
    return NO;
}

- (void)PaeDae_PrizeWillDisplay:(UIView *)view
{
    NSLog(@"PRIZE UNLOADED");
    UnitySendMessage("GameObject", "PrizeWillDisplay", "This is a test!");
}

- (void)PaeDae_PrizeUnloaded {
    NSLog(@"PRIZE UNLOADED");
    UnitySendMessage("GameObject", "PrizeUnloaded", "This is a test!");
}

@end
